//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evidencija
{
    using System;
    using System.Collections.Generic;
    
    public partial class vezaDjelatnikRad
    {
        public int id_djelatnik { get; set; }
        public int id_vrstaRada { get; set; }
        public Nullable<System.DateTime> pocetak { get; set; }
        public Nullable<System.DateTime> kraj { get; set; }
        public Nullable<int> brojSati { get; set; }
        public string danUTjednu { get; set; }
        public int id { get; set; }
        public Nullable<int> tjedanUGodini { get; set; }
        public Nullable<System.DateTime> prviDatumTjedna { get; set; }
        public string satPocetka { get; set; }
        public string satKraja { get; set; }
        public string mjesecUGodini { get; set; }
        public string danUMjesec { get; set; }
    
        public virtual djelatnik djelatnik { get; set; }
        public virtual vrstaRada vrstaRada { get; set; }
    }
}