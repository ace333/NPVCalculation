IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'CashFlowDb')
BEGIN
CREATE DATABASE [CashFlowDb]

END
GO
    USE [CashFlowDb]
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250527232147_InitialMigration'
)
BEGIN
    CREATE TABLE [CashFlow] (
        [Id] int NOT NULL IDENTITY,
        [DiscountRates_LowerBound] float NOT NULL,
        [DiscountRates_UpperBound] float NOT NULL,
        [Increment] float NOT NULL,
        CONSTRAINT [PK_CashFlow] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250527232147_InitialMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250527232147_InitialMigration', N'8.0.16');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250528054036_AdjustProperty'
)
BEGIN
    ALTER TABLE [CashFlow] ADD [HasNpvCalculation] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250528054036_AdjustProperty'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250528054036_AdjustProperty', N'8.0.16');
END;
GO

COMMIT;
GO

