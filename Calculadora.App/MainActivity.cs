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

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            view = (View)sender;

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.RecordAudio) != Android.Content.PM.Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.RecordAudio }, 12345);
            }
            GetTextFromVoice();
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

        private void GetTextFromVoice()
        {
            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                Text = "Não encontrei um microfone.";

                //Playback the sound
                PlayVoiceFromText(view).ConfigureAwait(false);
            }
            else
            {
                Intent voiceIntent = InitializeIntent();

                StartActivityForResult(voiceIntent, VOICE);
            }
        }

        private void VoiceActivityResult(Result resultVal, Intent data)
        {
            if (resultVal == Result.Ok)
            {
                string[] matches = data.GetStringArrayExtra(RecognizerIntent.ExtraResults);

                if (matches.Length > 0)
                {
                    Text = matches[0];

                    try
                    {
                        //Compute the result
                        Text = Lib.Calculadora.Init(Text);
                    }
                    catch
                    {
                        Text = null;
                    }
                }
            }

            if (string.IsNullOrEmpty(Text))
            {
                //Something happened, replay generic message
                Text = "Não consegui compreender, tente outra vez.";
            }

            //Playback the sound
            PlayVoiceFromText(view).ConfigureAwait(false);
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AppCompatButton fab = FindViewById<AppCompatButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        protected override void OnActivityResult(int requestCode, Result resultVal, Intent data)
        {
            if (requestCode == VOICE)
                VoiceActivityResult(resultVal, data);

            base.OnActivityResult(requestCode, resultVal, data);
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

