using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model for 'Marke' entity.
	/// </summary>
	public class Loggedin
	{
        [DisplayName("Loggedin")]
        public bool loggedin { get; set;} = false;
        /*public static bool logg=false;
        public static void Login(){
            logg=true;
        }
		public static bool isUserLoggedin(){
            return logg;
        }*/


	}
}