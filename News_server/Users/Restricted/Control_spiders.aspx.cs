using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using News_server.News_spiders;
using System.Diagnostics;

namespace News_server.Restricted
{
    public partial class Control_spiders : System.Web.UI.Page
    {
        string text = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Output_new.Text = text;
            Debug.WriteLine(text);
        }

        protected void update()
        {
            Output_new.Text = text;
            Debug.WriteLine(text);
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Output_new.Text = "";
            Response.Redirect(@"/Restricted\Main_panel.aspx");
        }

        protected void spider_theverge_com_Click(object sender, EventArgs e)
        {
            try
            {
                Spiders spider = new Spiders();
                Global_collection collection_news = new Global_collection();

                collection_news.add(spider.theverge_com());

                var list = collection_news.get();

                text = "";
                foreach (var element in list)
                {
                    //Debug.WriteLine("element.type);
                    text += "id = " + element.id.ToString() + "\n";
                    text += "type = " + element.type + "\n";
                    text += "sourse = " + element.source + "\n";
                    text += "title = " + element.title + "\n";
                    text += "content = " + element.content + "\n";
                    text += "image = " + element.image + "\n";
                    text += "\n";
                    Debug.WriteLine(text);
                }
                Output_new.Text = text;
                update();
                Label.Text = "Робота бота завершена.";
            }
            catch (Exception ex)
            {
                Label.Text = "Вызвано исключение: "+ex.Message;
            }
        }

        protected void theverge_com_inXml_Click(object sender, EventArgs e)
        {
            try
            {
                Spiders spider1 = new Spiders();
                Global_collection collection_news = new Global_collection();
                collection_news.add(spider1.theverge_com());
                collection_news.toXml();
                collection_news.toTxt();
                Label.Text = "Работа бота прошла успешно! файл сахранен в директори output";
            }
            catch (Exception ex)
            {
                Label.Text = "Вызвано исключение: " + ex.Message;
            }
        }

        protected void All_Click(object sender, EventArgs e)
        {
            Label.Text = "Робота бота завершена. Все данные находяться в директории output";
            try
            {
                Spiders spider = new Spiders();
                Global_collection collection_news = new Global_collection();

                collection_news.add(spider.theverge_com());

                var list = collection_news.get();

                text = "";
                foreach (var element in list)
                {
                    //Debug.WriteLine("element.type);
                    text += "id = " + element.id.ToString() + "\n";
                    text += "type = " + element.type + "\n";
                    text += "sourse = " + element.source + "\n";
                    text += "title = " + element.title + "\n";
                    text += "content = " + element.content + "\n";
                    text += "image = " + element.image + "\n";
                    text += "\n";
                    Debug.WriteLine(text);
                }
                Output_new.Text = text;

                collection_news.toXml();
                collection_news.toTxt();

                update();
                Label.Text = "Робота бота завершена. Все данные находяться в директории output";
            }
            catch(Exception ex)
            { Label.Text = "Вызвано исключение: "+ ex.Message; }
        }

        protected void ReadXml_Click(object sender, EventArgs e)
        {
            Global_collection collection_news = new Global_collection();

            collection_news.readXml();

            var list = collection_news.get();

            text = "";
            foreach (var element in list)
            {
                //Debug.WriteLine("element.type);
                text += "id = " + element.id.ToString() + "\n";
                text += "type = " + element.type + "\n";
                text += "sourse = " + element.source + "\n";
                text += "title = " + element.title + "\n";
                text += "content = " + element.content + "\n";
                text += "image = " + element.image + "\n";
                text += "\n";
                Debug.WriteLine(text);
            }
            Output_new.Text = text;

            update();
        }
    }
}