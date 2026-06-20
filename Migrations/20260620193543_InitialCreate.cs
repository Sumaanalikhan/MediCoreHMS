using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediCoreHMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedWard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ConsultationSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    AdmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    BedId = table.Column<int>(type: "int", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdmissionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentNotes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.AdmissionId);
                    table.ForeignKey(
                        name: "FK_Admissions_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "BedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "BedId", "BedNumber", "IsOccupied", "Ward" },
                values: new object[,]
                {
                    { 1, "G-1", false, "General" },
                    { 2, "G-2", false, "General" },
                    { 3, "G-3", false, "General" },
                    { 4, "G-4", false, "General" },
                    { 5, "G-5", false, "General" },
                    { 6, "G-6", false, "General" },
                    { 7, "G-7", false, "General" },
                    { 8, "G-8", false, "General" },
                    { 9, "G-9", false, "General" },
                    { 10, "G-10", false, "General" },
                    { 11, "G-11", false, "General" },
                    { 12, "G-12", false, "General" },
                    { 13, "G-13", false, "General" },
                    { 14, "ICU-1", false, "ICU" },
                    { 15, "ICU-2", false, "ICU" },
                    { 16, "ICU-3", false, "ICU" },
                    { 17, "ICU-4", false, "ICU" },
                    { 18, "ICU-5", false, "ICU" },
                    { 19, "ICU-6", false, "ICU" },
                    { 20, "ICU-7", false, "ICU" },
                    { 21, "ICU-8", false, "ICU" },
                    { 22, "M-1", false, "Maternity" },
                    { 23, "M-2", false, "Maternity" },
                    { 24, "M-3", false, "Maternity" },
                    { 25, "M-4", false, "Maternity" },
                    { 26, "M-5", false, "Maternity" },
                    { 27, "M-6", false, "Maternity" },
                    { 28, "M-7", false, "Maternity" },
                    { 29, "M-8", false, "Maternity" },
                    { 30, "M-9", false, "Maternity" },
                    { 31, "M-10", false, "Maternity" },
                    { 32, "P-1", false, "Pediatric" },
                    { 33, "P-2", false, "Pediatric" },
                    { 34, "P-3", false, "Pediatric" },
                    { 35, "P-4", false, "Pediatric" },
                    { 36, "P-5", false, "Pediatric" },
                    { 37, "P-6", false, "Pediatric" },
                    { 38, "P-7", false, "Pediatric" },
                    { 39, "P-8", false, "Pediatric" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "AssignedWard", "ConsultationSchedule", "FullName", "IsAvailable", "Specialization" },
                values: new object[,]
                {
                    { 1, "General", "9AM-3PM", "Dr. Ahmed Raza", true, "General Medicine" },
                    { 2, "ICU", "8AM-2PM", "Dr. Sara Khan", true, "Intensive Care" },
                    { 3, "Maternity", "10AM-4PM", "Dr. Fatima Malik", true, "Gynecology" },
                    { 4, "Pediatric", "9AM-1PM", "Dr. Usman Ali", false, "Pediatrics" },
                    { 5, "General", "2PM-8PM", "Dr. Bilal Qureshi", true, "General Medicine" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_BedId",
                table: "Admissions",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_DoctorId",
                table: "Admissions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientId",
                table: "Admissions",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
