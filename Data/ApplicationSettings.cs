using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
	public class ApplicationSettings
    {

	#region Singleton
	private static readonly ApplicationSettings _instance = new ApplicationSettings();

	private ApplicationSettings()
	{
	}

	public static ApplicationSettings Current
	{
		get { return _instance; }
	}
	#endregion

        readonly public string ConexionSQL = "Data Source=DESKTOP-EDJTHOR;Initial Catalog=ChallengeML;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
	}
}
