using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace EinkaufslisteV2.View

{
    //    public class Class1
    //    {
    //        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
    //        System.IO.StringWriter stringWriter = new System.IO.StringWriter(stringBuilder);
    //        System.Web.UI.HtmlTextWriter htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter); {
    //          htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.Ul);
    //          htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.Li);
    //          htmlTextWriter.RenderBeginTag(HtmlTextWriterTag.A);
    //          htmlTextWriter.AddAttribute(HtmlTextWriterAttribute.Href, "http://www.google.de");
    //          htmlTextWriter.Write("Google");
    //          htmlTextWriter.RenderEndTag();
    //          htmlTextWriter.RenderEndTag();
    //            HtmlTextWriter.RenderEndTag();
    // }
    //}
    //    }
    //}


    public class CheckboxButton
    {
        public string productname;
        public string GetElements(string produktName, string produktID)
        {

            // Initialize StringWriter instance.
            StringWriter stringWriter = new StringWriter();

            // Put HtmlTextWriter in using block because it needs to call Dispose.
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {

                // Some strings for the attributes.
                string LlbClassValue = "btn btn-primary";
                //string DivClassValue = "btn-group";

                //   <div class="btn-group" data-toggle="buttons">

                //writer.AddAttribute(HtmlTextWriterAttribute.Class, DivClassValue);
                //writer.AddAttribute("data-toggle", "buttons");
                //writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.AddAttribute(HtmlTextWriterAttribute.Class, LlbClassValue);
                writer.RenderBeginTag(HtmlTextWriterTag.Label); // Begin #1
                writer.AddAttribute(HtmlTextWriterAttribute.AutoComplete, "Off");
               // writer.AddAttribute(HtmlTextWriterAttribute.Value, productname);
                writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");
                writer.AddAttribute(HtmlTextWriterAttribute.Id, produktID);
                writer.AddAttribute(HtmlTextWriterAttribute.Name, produktID);
                writer.RenderBeginTag(HtmlTextWriterTag.Input); // Begin #2
                writer.RenderEndTag();// End #1
                writer.Write(produktName);
                writer.RenderEndTag(); // End #2
                writer.RenderBeginTag(HtmlTextWriterTag.Br);
                writer.RenderEndTag(); 


            }
            // Return the result.
            return stringWriter.ToString();
        }
    }
}