using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 评教系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://gsmis.graduate.buaa.edu.cn/gsmis/toModule.do?prefix=/py&page=/pyKkml.do?do=PyPjxstxxx");
        }

        private void Judge()
        {
          //  HtmlDocument doc = webBrowser1.Document;
            HtmlDocument doc = webBrowser1.Document.Window.Frames["detailFrame"].Document;
            var collection = doc.GetElementsByTagName("input");
            foreach(var input in collection)
            {
                ;
            }
            
        }

        private void search()
        {
            HtmlDocument doc = webBrowser1.Document;

         
            var collection = doc.GetElementsByTagName("tr");
            bool Isleft = false;

            foreach (HtmlElement ele in collection)
            {

                if (ele.InnerHtml.Contains("未评教"))
                {
                    Isleft = true;
                    var trcollection = ele.Children;
                    foreach (HtmlElement child in trcollection)
                    {
                        foreach (HtmlElement a in child.Children)
                        {
                            if (a.TagName == "A" && a.InnerText == "评教")
                            {
                                a.InvokeMember("Click");
                                Judge();

                            }
                        }
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtmlDocument doc = webBrowser1.Document.Window.Frames["detailFrame"].Document;
            var collection = doc.GetElementsByTagName("input");
            foreach (HtmlElement  input in collection)
            {
                if (input.GetAttribute("type") == "radio")
                {
                    input.InvokeMember("Click");
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                HtmlDocument doc = webBrowser1.Document.Window.Frames["detailFrame"].Document;
                var collection = doc.GetElementsByTagName("input");
                if (collection.Count > 0)
                {
                    ;
                }
                else
                    return;
                foreach (HtmlElement input in collection)
                {
                    if (input.GetAttribute("type") == "radio"&&input.GetAttribute("value")=="y")
                    {
                        input.InvokeMember("Click");
                    }
                }

                collection = doc.GetElementsByTagName("textarea");
                foreach (HtmlElement input in collection)
                {
                    input.SetAttribute("value", "课很有收获");
                }

                collection = doc.GetElementsByTagName("input");
                foreach (HtmlElement input in collection)
                {
                    if (input.GetAttribute("type") == "button" && input.GetAttribute("value") == "保存")
                    {
                        input.InvokeMember("Click");
                        webBrowser1.Refresh();
                        search();
                    }
                }     
            }
            catch(Exception)
            {
                ;
            }
        }
    }
}
