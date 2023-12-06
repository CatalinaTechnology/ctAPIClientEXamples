using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPIClient
{
	class Program
	{
		static void Main(string[] args)
		{
			Program myProgram = new Program();
			myProgram.RunIT();
		}

		public void RunIT()
		{
			var returnValue = ProjectMaintenanceService.getProjectByExactID("EN123004");
		}

		private ctAPI.ProjectMaintenance.projectMaintenance _projectMaintenanceService = null;
		private ctAPI.ProjectMaintenance.projectMaintenance ProjectMaintenanceService
		{
			get
			{
				if (_projectMaintenanceService == null)
				{
					_projectMaintenanceService = new ctAPI.ProjectMaintenance.projectMaintenance
					{
						ctDynamicsSLHeaderValue = new ctAPI.ProjectMaintenance.ctDynamicsSLHeader
						{
							siteID = "YOURSITEIDHERE",
							cpnyID = "YOURCPNYIDHERE",
							licenseKey = "YOURLICENSEKEYHERE",
							licenseName = "YOURLICENSENAMEHERE",
							licenseExpiration = "1/1/2020",
							siteKey = "YOURSITEKEYHERE",
							softwareName = "CTAPI"
						}
					};
				}

				return this._projectMaintenanceService;
			}
			set
			{
				this._projectMaintenanceService = value;
			}
		}
	}

}
