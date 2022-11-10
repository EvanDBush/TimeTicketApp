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

BEGIN TRANSACTION;

ALTER TABLE "TimeTickets" ADD "ProjectId" INTEGER NULL;

ALTER TABLE "Employees" ADD "ProjectId" INTEGER NULL;

CREATE TABLE "Projects" (
    "ProjectId" INTEGER NOT NULL CONSTRAINT "PK_Projects" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Budget" TEXT NOT NULL
);

CREATE INDEX "IX_TimeTickets_ProjectId" ON "TimeTickets" ("ProjectId");

CREATE INDEX "IX_Employees_ProjectId" ON "Employees" ("ProjectId");

CREATE TABLE "ef_temp_Employees" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Employees" PRIMARY KEY AUTOINCREMENT,
    "EMail" TEXT NULL,
    "FirstName" TEXT NULL,
    "HourlyRate" TEXT NOT NULL,
    "LastName" TEXT NULL,
    "ProjectId" INTEGER NULL,
    "TaxWithholding" TEXT NOT NULL,
    CONSTRAINT "FK_Employees_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("ProjectId")
);

INSERT INTO "ef_temp_Employees" ("Id", "EMail", "FirstName", "HourlyRate", "LastName", "ProjectId", "TaxWithholding")
SELECT "Id", "EMail", "FirstName", "HourlyRate", "LastName", "ProjectId", "TaxWithholding"
FROM "Employees";

CREATE TABLE "ef_temp_TimeTickets" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TimeTickets" PRIMARY KEY AUTOINCREMENT,
    "DateTime" TEXT NOT NULL,
    "EmployeeId" INTEGER NOT NULL,
    "Hours" TEXT NOT NULL,
    "ProjectId" INTEGER NULL,
    CONSTRAINT "FK_TimeTickets_Employees_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES "Employees" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_TimeTickets_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("ProjectId")
);

INSERT INTO "ef_temp_TimeTickets" ("Id", "DateTime", "EmployeeId", "Hours", "ProjectId")
SELECT "Id", "DateTime", "EmployeeId", "Hours", "ProjectId"
FROM "TimeTickets";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Employees";

ALTER TABLE "ef_temp_Employees" RENAME TO "Employees";

DROP TABLE "TimeTickets";

ALTER TABLE "ef_temp_TimeTickets" RENAME TO "TimeTickets";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_Employees_ProjectId" ON "Employees" ("ProjectId");

CREATE INDEX "IX_TimeTickets_EmployeeId" ON "TimeTickets" ("EmployeeId");

CREATE INDEX "IX_TimeTickets_ProjectId" ON "TimeTickets" ("ProjectId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221109222047_addedprojects', '7.0.0');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "ef_temp_TimeTickets" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TimeTickets" PRIMARY KEY AUTOINCREMENT,
    "DateTime" TEXT NOT NULL,
    "EmployeeId" INTEGER NULL,
    "Hours" TEXT NOT NULL,
    "ProjectId" INTEGER NULL,
    CONSTRAINT "FK_TimeTickets_Employees_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES "Employees" ("Id"),
    CONSTRAINT "FK_TimeTickets_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects" ("ProjectId")
);

INSERT INTO "ef_temp_TimeTickets" ("Id", "DateTime", "EmployeeId", "Hours", "ProjectId")
SELECT "Id", "DateTime", "EmployeeId", "Hours", "ProjectId"
FROM "TimeTickets";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "TimeTickets";

ALTER TABLE "ef_temp_TimeTickets" RENAME TO "TimeTickets";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_TimeTickets_EmployeeId" ON "TimeTickets" ("EmployeeId");

CREATE INDEX "IX_TimeTickets_ProjectId" ON "TimeTickets" ("ProjectId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221109222331_removesemployeeid', '7.0.0');

COMMIT;

