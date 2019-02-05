using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace WebApplication5
{
    public partial class _default : System.Web.UI.Page
    {





        public class Owner
        {
            public int reputation { get; set; }
            public int user_id { get; set; }
            public string user_type { get; set; }
            public int accept_rate { get; set; }
            public string profile_image { get; set; }
            public string display_name { get; set; }
            public string link { get; set; }
        }

        public class Item
        {
            public List<string> tags { get; set; }
            public Owner owner { get; set; }
           // public bool is_answered { get; set; }
            //public int view_count { get; set; }
            //public int accepted_answer_id { get; set; }
         //   public int answer_count { get; set; }
            //public int score { get; set; }
            //public int last_activity_date { get; set; }
            //public int creation_date { get; set; }
            //public int question_id { get; set; }
            public string link { get; set; }
            public string title { get; set; }
           // public int? last_edit_date { get; set; }
          //  public int? closed_date { get; set; }
          //  public string closed_reason { get; set; }
        }

        public class Item2
        {
            public List<string> tags { get; set; }
            public Owner owner { get; set; }
             public bool is_answered { get; set; }
            public int view_count { get; set; }
         //   public int accepted_answer_id { get; set; }
            public int answer_count { get; set; }
            public int score { get; set; }
          //  public int last_activity_date { get; set; }
          //  public int creation_date { get; set; }
            public int question_id { get; set; }
            public string link { get; set; }
            public string title { get; set; }
          //   public int? last_edit_date { get; set; }
         //   public int? closed_date { get; set; }
            public string closed_reason { get; set; }
        }
        public class RootObject
        {
            public List<Item> items { get; set; }
            public bool has_more { get; set; }
            public int quota_max { get; set; }
            public int quota_remaining { get; set; }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Length == 0)
            {
                this.txtName.Text = "Andriod";
            }

            string url = string.Format("https://api.stackexchange.com/2.2/search?pagesize=10&order=desc&sort="+ DropDownList1.SelectedValue + "&intitle=" + txtName.Text + "&site=stackoverflow");
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";

            HttpWebResponse responseObject = (HttpWebResponse)request.GetResponse();

            string urlsr = null;
            Stream stream = responseObject.GetResponseStream();

            StreamReader sr = new StreamReader(stream);
            urlsr = sr.ReadToEnd();

            dynamic jsondata = JsonConvert.DeserializeObject(urlsr);
            var ruslet = new List<Item>();
            var rusletDetail = new List<Item2>();
            foreach (var item in jsondata.items)
            {
                ruslet.Add(new Item
                {
                    title = item.title,
                    link = item.link,
                    //   is_answered = item.is_answered,
                    //   question_id = item.question_id,
                    //   creation_date = item.creation_date,
                    // last_edit_date = item.last_edit_date,
                    //  last_activity_date = item.last_activity_date,
                    //  score = item.score,
                    //   answer_count = item.answer_count


                });
            }
            foreach (var item2 in jsondata.items)
            {
                rusletDetail.Add(new Item2
                {
                 //   owner = item2.owner,
                    title = item2.title,
                    link = item2.link,
                    is_answered = item2.is_answered,
                    question_id = item2.question_id,                    
                    view_count = item2.view_count,
                    score = item2.score,
                    answer_count = item2.answer_count,
                    closed_reason = item2.closed_reason,
                 //   tags = item2.tags


                });

            }
            GridView1.DataSource = ruslet;
            GridView1.DataBind();

            DetailsView1.DataSource = rusletDetail;
            DetailsView1.DataBind();
        }
        /// <summary>
        /// ///////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtName.Text.Length == 0)
            {
                this.txtName.Text = "Andriod";
            }
            string id1 = GridView1.SelectedRow.Cells[0].Text;
            string id = GridView1.SelectedRow.Cells[3].Text;
            //txtName.Text = id;

            string url = string.Format("https://api.stackexchange.com/2.2/search?pagesize=10&order=desc&intitle=" + id + "&site=stackoverflow");
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";

            HttpWebResponse responseObject = (HttpWebResponse)request.GetResponse();

            string urlsr = null;
            Stream stream = responseObject.GetResponseStream();

            StreamReader sr = new StreamReader(stream);
            urlsr = sr.ReadToEnd();

            dynamic jsondata = JsonConvert.DeserializeObject(urlsr);
            var ruslet = new List<Item>();
            var rusletDetail = new List<Item2>();
            foreach (var item in jsondata.items)
            {
                ruslet.Add(new Item
                {
                    title = item.title,
                    link = item.link,
                    //   is_answered = item.is_answered,
                    //   question_id = item.question_id,
                    //   creation_date = item.creation_date,
                    // last_edit_date = item.last_edit_date,
                    //  last_activity_date = item.last_activity_date,
                    //  score = item.score,
                    //   answer_count = item.answer_count


                });
            }
            foreach (var item2 in jsondata.items)
            {
                rusletDetail.Add(new Item2
                {
               //     owner = item2.owner,
                    title = item2.title,
                    link = item2.link,
                    is_answered = item2.is_answered,
                    question_id = item2.question_id,
                    view_count = item2.view_count,
                    score = item2.score,
                    answer_count = item2.answer_count,
                    closed_reason = item2.closed_reason,
                   // tags = item2.tags


                });

            }
         //   GridView1.DataSource = ruslet;
         //   GridView1.DataBind();

            DetailsView1.DataSource = rusletDetail;
            DetailsView1.DataBind();
        }
    }

    }

