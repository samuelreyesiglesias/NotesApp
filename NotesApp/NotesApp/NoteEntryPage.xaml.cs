using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NotesApp.Models;
using System.IO;

namespace NotesApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteEntryPage : ContentPage
	{
		public NoteEntryPage ()
		{
			InitializeComponent ();
		}

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Note nuevaNota = new Note();
            nuevaNota.Text = EditorNote.Text;
            nuevaNota.Date = DateTime.UtcNow;
            //Guardarlo en la BD. crearNote de este metodo.
            NoteDatabase DataBase = new NoteDatabase
                (Path.Combine
                (Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));

            int Result = DataBase.CreatetNote(nuevaNota);
            if(Result == 1)
            {
                DisplayAlert("Aviso", $"Registro ingresado con exito.ID:{nuevaNota.ID}", "ok");
            }
            Navigation.PopAsync();
         
        }
        void OnDeleteButtonClicked(object sender, EventArgs e)
        {

        }
    }
}