//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP320_Kolpakov.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exam
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> ExDate { get; set; }
        public Nullable<int> DiscID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> TeacherID { get; set; }
        public string Cabinet { get; set; }
        public Nullable<int> Grade { get; set; }
    
        public virtual Disciple Disciple { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}