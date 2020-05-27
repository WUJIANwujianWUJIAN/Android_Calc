using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Webkit;
using Android.Net.Http;
using System.IO;
using Android.Views;



namespace _7_Test
{

    public class HelloWebViewClient : WebViewClient
    {
        // For API level 24 and later
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            view.LoadUrl(request.Url.ToString());
            return false;
        }

        public void onReceivedSslError(WebView view, SslErrorHandler handler, SslError error)
        {
            handler.Proceed();//接受所有网站的证书
        }
    }

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btn1;
        WebView webview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btn1 = (Button)FindViewById(Resource.Id.button1);
            webview = FindViewById<WebView>(Resource.Id.webView1);


            btn1.Click += Btn1;

            global::Android.Webkit.WebView.SetWebContentsDebuggingEnabled(true);
            webview.Settings.JavaScriptEnabled = true;


            //string content;
            //using (StreamReader sr = new StreamReader(Assets.Open("index.html")))
            //{
            //    content = sr.ReadToEnd();
            //}
            //// Set TextView.Text to our asset content

            //webview.LoadDataWithBaseURL(null, content, "text/html; charset=UTF-8", "UTF-8", null);
            webview.LoadUrl("file:///android_asset/tt.html");
        }


        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && webview.CanGoBack())
            {
                webview.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        public void Btn1(object sender, System.EventArgs e)
        {
            //SetTitle(Resource.String.tittle1);
            webview.ClearCache(false);
            webview.ClearHistory();
            webview.DestroyDrawingCache();
            webview.Destroy();
            Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}