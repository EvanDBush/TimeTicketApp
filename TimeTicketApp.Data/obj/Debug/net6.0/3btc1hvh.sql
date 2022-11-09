CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Employees" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Employees" PRIMARY KEY AUTOINCREMENT,
    "FirstName" TEXT NULL,
    "LastName" TEXT NULL,
    "EMail" TEXT NULL,
    "TaxWithholding" TEXT NOT NULL,
    "HourlyRate" TEXT NOT NULL
);

CREATE TABLE "TimeTickets" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TimeTickets" PRIMARY KEY AUTOINCREMENT,
    "Hours" TEXT NOT NULL,
    "EmployeeId" INTEGER NOT NULL,
    "DateTime" TEXT NOT NULL,
    CONSTRAINT "FK_TimeTickets_Employees_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES "Employees" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_TimeTickets_EmployeeId" ON "TimeTickets" ("EmployeeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221109182940_init', '7.0.0');

COMMIT;

