namespace LayUI.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using LayUI.Data.EntityModel;
    public partial class TeamWorkDbContext : DbContext
    {
        static TeamWorkDbContext() 
        {
            Database.SetInitializer<TeamWorkDbContext>(null);
        }

        public TeamWorkDbContext()
            : base("name=TeamWorkDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

		public virtual DbSet<T_WH_DangerChemPro_Entity> T_WH_DangerChemPro_Entity { get; set; }
		public virtual DbSet<T_WH_DangerChemUse_Entity> T_WH_DangerChemUse_Entity { get; set; }
		public virtual DbSet<T_WH_Evaluate_Entity> T_WH_Evaluate_Entity { get; set; }
		public virtual DbSet<T_WH_Isotope_Entity> T_WH_Isotope_Entity { get; set; }
		public virtual DbSet<T_WH_MajorHazardDossier_Entity> T_WH_MajorHazardDossier_Entity { get; set; }
		public virtual DbSet<T_WH_PersonRecord_Entity> T_WH_PersonRecord_Entity { get; set; }
		public virtual DbSet<T_WH_Toxic_Entity> T_WH_Toxic_Entity { get; set; }
		public virtual DbSet<T_XT_Data_Entity> T_XT_Data_Entity { get; set; }
		public virtual DbSet<T_XT_Doc_Entity> T_XT_Doc_Entity { get; set; }
		public virtual DbSet<T_XT_LogRecords_Entity> T_XT_LogRecords_Entity { get; set; }
		public virtual DbSet<T_XT_StoreDirectory_Entity> T_XT_StoreDirectory_Entity { get; set; }
		public virtual DbSet<T_XT_User_Entity> T_XT_User_Entity { get; set; }
		public virtual DbSet<T_YH_HiddenDanger_Entity> T_YH_HiddenDanger_Entity { get; set; }
		public virtual DbSet<T_YH_Records_Entity> T_YH_Records_Entity { get; set; }
		public virtual DbSet<T_YH_SumRecords_Entity> T_YH_SumRecords_Entity { get; set; }
 
    }
}

  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  


