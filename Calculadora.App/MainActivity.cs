using System;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace Calculadora.App
{
    [Activity(Label = "Calculadora", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        View view;

        const int VOICE = 10;

        string Text;

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
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.RecordAudio }, 12345);
            }
            GetTextFromVoice();
        }

        private async Task PlayVoiceFromText(View view)
        {
            SpeechOptions options = new SpeechOptions()
            {
                Volume = 1,
                Pitch = 1.0f,
            };


            await TextToSpeech.SpeakAsync(Text, options);

            Snackbar.Make(view, Text, Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        private void GetTextFromVoice()
        {
            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                Text = "Não encontrei um microfone.";

                //Playback the sound
                PlayVoiceFromText(view);
            }
            else
            {
                Intent voiceIntent = InitializeIntent();

                StartActivityForResult(voiceIntent, VOICE);
            }
        }

        private static Intent InitializeIntent()
        {
            Intent voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

            voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Qual a operação?");

            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

            voiceIntent.PutExtra(RecognizerIntent.ExtraResults, Java.Util.Locale.Default);
            return voiceIntent;
        }

        protected override void OnActivityResult(int requestCode, Result resultVal, Intent data) 
        {
            if(requestCode == VOICE)
            {
                if(resultVal == Result.Ok)
                {
                    //TODOFD
                    //Não sei honestamente o que fazer com esta coisa..
                    // Vem palavra a palavra?
                    //pesquisa isto.
                    string[] matches = data.GetStringArrayExtra(RecognizerIntent.ExtraResults);

                    //desperdicio de ciclos de relogio com p ciclo em baixo
                    //if(matches.Length != 0)
                    //{
                    //    text = matches[0];
                    //}

                    foreach (var match in matches)
                    {
                        Text = match;

                        //Debug
                        Wait(1000);
                        PlayVoiceFromText(view);


                        try
                        {
                            //Compute the result
                            Text = Lib.Calculadora.Init(Text);
                            break;
                        }
                        catch 
                        {
                            continue;
                        }
                    }
                }

                if (string.IsNullOrEmpty(Text))
                {
                    //Something happened, replay generic message
                    Text = "Nenhuma operação pedida, tente outra vez.";
                }

                //Playback the sound
                PlayVoiceFromText(view);
                return;
            }
            base.OnActivityResult(requestCode, resultVal, data);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

