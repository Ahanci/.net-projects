using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moon_light_rest_api.entities
{
    public class Parent
    {
        public int Id { get; set; }             // Primary key
        public required string Name { get; set; }        // Veli adı
        public required string PhoneNumber { get; set; } // İletişim numarası

        public string? Email { get; set; }       // E-posta adresi

        public int[]? StudentIds { get; set; } // İlişkili öğrenci kimlikleri


    }

    public class Student
    {
        public int Id { get; set; }             // Primary key
        public required string Name { get; set; }        // Veli adı
        public DateTime DateOfBirth { get; set; } // Doğum tarihi

        public bool IsActive { get; set; }      // Aktiflik durumu

        public int ParentId { get; set; }       // Yabancı anahtar
        // public Parent Parent { get; set; }      // Navigasyon özelliği


    }
}