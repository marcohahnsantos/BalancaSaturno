using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content.PM;
using Android.Views;

namespace SATCARGO.Activitys
{
    [Activity(Label = "ActSenhaCalibracao", Theme = "@style/AppThemeSelecionar1", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActSenhaCalibracao : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LayoutSenhaCal);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "LIBERAÇÃO CALIBRAÇÃO";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            Android.Support.V7.Widget.AppCompatImageButton BtnSair = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSair);
            Android.Support.V7.Widget.AppCompatImageButton BtnSalvar = FindViewById<Android.Support.V7.Widget.AppCompatImageButton>(Resource.Id.BtnSalvar);
            Android.Support.V7.Widget.AppCompatEditText Senha = FindViewById<Android.Support.V7.Widget.AppCompatEditText>(Resource.Id.TxtSenha);
            Window.SetSoftInputMode(SoftInput.StateHidden);

            BtnSair.Click += delegate
            {
                Finish();
            };

            BtnSalvar.Click += delegate
            {
                if (Senha.Text != "2901")
                {
                    Toast.MakeText(this, "SENHA INVÁLIDA !", ToastLength.Short).Show();
                    return;
                }
                else
                {
                    Validacoes.SenhaCalibracao = true;
                    Toast.MakeText(this, "SENHA VÁLIDA !", ToastLength.Short).Show();
                    Finish();
                }
            };


        }


    }
}