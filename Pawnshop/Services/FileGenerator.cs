using Pawnshop.DB;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.Services
{
    public class FileGenerator
    {
        public static void Generate(Contract contract)
        {
            Document doc = new Document();
            doc.LoadFromFile(@"..\..\Resources\contractTemplate.docx");
            doc.Replace("Contract.Date", contract.Date.ToString("dd.MM.yyyy"), true, true);
            doc.Replace("Contract.ExpireDate", contract.ExpireDate.ToString("dd.MM.yyyy"), true, true);

            doc.Replace("Client.LastName", contract.Client.LastName, true, true);
            doc.Replace("Client.FirstName", contract.Client.FirstName, true, true);
            doc.Replace(" Client.Patronymic", string.IsNullOrEmpty(contract.Client.Patronymic) ?
                                              "" : contract.Client.Patronymic, true, true);
            doc.Replace("Client.Passport", contract.Client.Passport, true, true);

            Section section = doc.Sections[0];
            TextSelection selection = doc.FindString("Products", true, true);
            TextRange range = selection.GetAsOneRange();
            Paragraph paragraph = range.OwnerParagraph;
            Body body = paragraph.OwnerTextBody;
            int index = body.ChildObjects.IndexOf(paragraph);

            Table table = section.AddTable(true);
            table.ResetCells(contract.Products.Count() + 1, 4);
            table.AutoFit(AutoFitBehaviorType.AutoFitToWindow);

            table[0, 0].AddParagraph().AppendText("№");
            table[0, 1].AddParagraph().AppendText("Название");
            table[0, 2].AddParagraph().AppendText("Стоимость");
            table[0, 3].AddParagraph().AppendText("Комиссия");

            for (int i = 1; i <= contract.Products.Count(); i++)
            {
                table[i, 0].AddParagraph().AppendText(i.ToString());
                table[i, 1].AddParagraph().AppendText(contract.Products.ElementAt(i - 1).Name);
                table[i, 2].AddParagraph().AppendText(contract.Products.ElementAt(i - 1).Price.ToString());
                table[i, 3].AddParagraph().AppendText(contract.Products.ElementAt(i - 1).Commission.ToString());
            }

            body.ChildObjects.Remove(paragraph);
            body.ChildObjects.Insert(index, table);

            doc.SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $@"\Договоры\Договор №{contract.Id}.docx", FileFormat.Docx);
        }
    }
}
