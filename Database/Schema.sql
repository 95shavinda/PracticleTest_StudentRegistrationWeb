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

CREATE TABLE [Students] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Mobile] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NIC] nvarchar(max) NULL,
    [DateOfBirth] date NOT NULL,
    [Address] nvarchar(max) NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240807174936_Init', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Students].[NIC]', N'Nic', N'COLUMN';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'Nic');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var0 + '];');
UPDATE [Students] SET [Nic] = N'' WHERE [Nic] IS NULL;
ALTER TABLE [Students] ALTER COLUMN [Nic] nvarchar(max) NOT NULL;
ALTER TABLE [Students] ADD DEFAULT N'' FOR [Nic];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'Mobile');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var1 + '];');
UPDATE [Students] SET [Mobile] = N'' WHERE [Mobile] IS NULL;
ALTER TABLE [Students] ALTER COLUMN [Mobile] nvarchar(max) NOT NULL;
ALTER TABLE [Students] ADD DEFAULT N'' FOR [Mobile];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'LastName');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var2 + '];');
UPDATE [Students] SET [LastName] = N'' WHERE [LastName] IS NULL;
ALTER TABLE [Students] ALTER COLUMN [LastName] nvarchar(max) NOT NULL;
ALTER TABLE [Students] ADD DEFAULT N'' FOR [LastName];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'FirstName');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var3 + '];');
UPDATE [Students] SET [FirstName] = N'' WHERE [FirstName] IS NULL;
ALTER TABLE [Students] ALTER COLUMN [FirstName] nvarchar(max) NOT NULL;
ALTER TABLE [Students] ADD DEFAULT N'' FOR [FirstName];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'Email');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var4 + '];');
UPDATE [Students] SET [Email] = N'' WHERE [Email] IS NULL;
ALTER TABLE [Students] ALTER COLUMN [Email] nvarchar(max) NOT NULL;
ALTER TABLE [Students] ADD DEFAULT N'' FOR [Email];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'Address');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var5 + '];');
UPDATE [Students] SET [Address] = N'' WHERE [Address] IS NULL;
ALTER TABLE [Students] ALTER COLUMN [Address] nvarchar(max) NOT NULL;
ALTER TABLE [Students] ADD DEFAULT N'' FOR [Address];
GO

ALTER TABLE [Students] ADD [ImageURL] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240809093920_add_image_url', N'8.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Students].[ImageURL]', N'ImageUrl', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240809141037_Rename-ImgUrl', N'8.0.7');
GO

COMMIT;
GO