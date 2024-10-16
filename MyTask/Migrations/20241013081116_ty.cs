using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTask.Migrations
{
    public partial class ty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Prescript_doctor_fk",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "Prescript_medication_fk",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "Prescript_Patient_fk",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Prescriptions",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicationID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Prescriptions",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "Prescript_doctor_fk",
                table: "Prescriptions",
                column: "DoctorID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Prescript_medication_fk",
                table: "Prescriptions",
                column: "MedicationID",
                principalTable: "Medications",
                principalColumn: "MedicationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Prescript_Patient_fk",
                table: "Prescriptions",
                column: "PatientID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Prescript_doctor_fk",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "Prescript_medication_fk",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "Prescript_Patient_fk",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Prescriptions",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicationID",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Prescriptions",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorID",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "Prescript_doctor_fk",
                table: "Prescriptions",
                column: "DoctorID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "Prescript_medication_fk",
                table: "Prescriptions",
                column: "MedicationID",
                principalTable: "Medications",
                principalColumn: "MedicationID");

            migrationBuilder.AddForeignKey(
                name: "Prescript_Patient_fk",
                table: "Prescriptions",
                column: "PatientID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
