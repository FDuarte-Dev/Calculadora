using System;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Android.Speech.Tts;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace Calculadora.App
{
    [Activity(Label = "Calculadora", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, TextToSpeech.IOnInitListener
    {
        View view;

        bool isRecording;
        const int VOICE = 10;

        string text;

        TextToSpeech tts;
        Java.Util.Locale lang;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AppCompatButton fab = FindViewById<AppCompatButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            view = (View)sender;
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.RecordAudio) != Android.Content.PM.Permission.Granted)
            {
                //TODOFD - Grant permission
            }
            GetTextFromVoice();
        }

        private void PlayVoiceFromText(View view)
        {
            tts = new TextToSpeech(this, this, "com.google.android.tts");

            lang = Java.Util.Locale.Default;

            tts.SetLanguage(lang);
            tts.SetPitch(.5f);
            tts.SetSpeechRate(.5f);

            tts.Speak(text, QueueMode.Flush, null);

            Snackbar.Make(view, text, Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        private void GetTextFromVoice()
        {
            isRecording = false;

            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                text = string.Empty;
            }
            else
            {
                isRecording = true;
                if (isRecording)
                {
                    Intent voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                    voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

                    voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Qual a operação?");

                    voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                    voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
                    voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 1500);
                    voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

                    voiceIntent.PutExtra(RecognizerIntent.ExtraResults, Java.Util.Locale.Default);

                    StartActivityForResult(voiceIntent, VOICE);
                }
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultVal, Intent data) 
        {
            if(requestCode == VOICE)
            {
                if(resultVal == Result.Ok)
                {
                    string[] matches = data.GetStringArrayExtra(RecognizerIntent.ExtraResults);
                    if(matches.Length != 0)
                    {
                        text = matches[0];
                    }

                    foreach (var match in matches)
                    {
                        text = match;

                        try
                        {
                            //Compute the result
                            text = Lib.Calculadora.Init(text);
                            break;
                        }
                        catch 
                        {
                            continue;
                        }
                    }
                }

                if (string.IsNullOrEmpty(text))
                {
                    //Something happened, replay generic message
                    text = "Nenhuma operação pedida, tente outra vez.";
                }
                
                //Playback the sound
                PlayVoiceFromText(view);
            }
            base.OnActivityResult(requestCode, resultVal, data);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status == OperationResult.Error)
                tts.SetLanguage(Java.Util.Locale.Default);
            if (status == OperationResult.Success)
                tts.SetLanguage(lang);
        }
    }
}

