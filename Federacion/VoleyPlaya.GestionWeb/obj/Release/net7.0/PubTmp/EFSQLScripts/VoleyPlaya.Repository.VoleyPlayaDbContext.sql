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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'7.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [Categorias] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime NOT NULL,
        [UpdatedDate] datetime NOT NULL,
        [CreatedBy] nvarchar(256) NULL,
        [UpdatedBy] nvarchar(256) NULL,
        [Nombre] nvarchar(450) NULL,
        CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [Competiciones] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime NOT NULL,
        [UpdatedDate] datetime NOT NULL,
        [CreatedBy] nvarchar(256) NULL,
        [UpdatedBy] nvarchar(256) NULL,
        [Nombre] nvarchar(450) NULL,
        CONSTRAINT [PK_Competiciones] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [Temporadas] (
        [Id] int NOT NULL IDENTITY,
        [CreatedDate] datetime NOT NULL,
        [UpdatedDate] datetime NOT NULL,
        [CreatedBy] nvarchar(256) NULL,
        [UpdatedBy] nvarchar(256) NULL,
        [Nombre] nvarchar(450) NULL,
        CONSTRAINT [PK_Temporadas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [Ediciones] (
        [Id] int NOT NULL IDENTITY,
        [TemporadaId] int NOT NULL,
        [CompeticionId] int NOT NULL,
        [CategoriaId] int NOT NULL,
        [Genero] nvarchar(max) NULL,
        [TipoCalendario] nvarchar(max) NULL,
        [Lugar] nvarchar(max) NULL,
        [CreatedDate] datetime NOT NULL,
        [UpdatedDate] datetime NOT NULL,
        [CreatedBy] nvarchar(256) NULL,
        [UpdatedBy] nvarchar(256) NULL,
        [Nombre] nvarchar(450) NULL,
        CONSTRAINT [PK_Ediciones] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_dbo.EdicionCategoria_Id] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]),
        CONSTRAINT [FK_dbo.EdicionCompeticion_Id] FOREIGN KEY ([CompeticionId]) REFERENCES [Competiciones] ([Id]),
        CONSTRAINT [FK_dbo.EdicionTemporada_Id] FOREIGN KEY ([TemporadaId]) REFERENCES [Temporadas] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [EdicionGrupos] (
        [Id] int NOT NULL IDENTITY,
        [EdicionId] int NOT NULL,
        [Tipo] nvarchar(max) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [UpdatedBy] nvarchar(max) NULL,
        [Nombre] nvarchar(450) NULL,
        CONSTRAINT [PK_EdicionGrupos] PRIMARY KEY ([Id]),
        CONSTRAINT [Fk_dbo.EdicionGrupoEdicion_Id] FOREIGN KEY ([EdicionId]) REFERENCES [Ediciones] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [Jornada] (
        [Id] int NOT NULL IDENTITY,
        [Numero] int NOT NULL,
        [Fecha] datetime2 NOT NULL,
        [EdicionId] int NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        [CreatedBy] nvarchar(max) NULL,
        [UpdatedBy] nvarchar(max) NULL,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Jornada] PRIMARY KEY ([Id]),
        CONSTRAINT [Fk_dbo.EdicionJornada_Id] FOREIGN KEY ([EdicionId]) REFERENCES [Ediciones] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [Equipos] (
        [Id] int NOT NULL IDENTITY,
        [EdicionId] int NOT NULL,
        [EdicionGrupoId] int NULL,
        [OrdenCalendario] int NULL,
        [Jugados] int NULL,
        [Ganados] int NULL,
        [Perdidos] int NULL,
        [PuntosFavor] int NULL,
        [PuntosContra] int NULL,
        [Coeficiente] float NULL,
        [Puntos] int NULL,
        [CreatedDate] datetime NOT NULL,
        [UpdatedDate] datetime NOT NULL,
        [CreatedBy] nvarchar(256) NULL,
        [UpdatedBy] nvarchar(256) NULL,
        [Nombre] nvarchar(450) NULL,
        CONSTRAINT [PK_Equipos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Equipos_EdicionGrupos_EdicionGrupoId] FOREIGN KEY ([EdicionGrupoId]) REFERENCES [EdicionGrupos] ([Id]),
        CONSTRAINT [FK_dbo.Equipo_dbo.Edicion_Id] FOREIGN KEY ([EdicionId]) REFERENCES [Ediciones] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [Partidos] (
        [Id] int NOT NULL IDENTITY,
        [GrupoId] int NOT NULL,
        [EquipoLocalId] int NOT NULL,
        [EquipoVisitanteId] int NOT NULL,
        [ResultadoLocal] int NULL,
        [ResultadoVisitante] int NULL,
        [Jornada] int NULL,
        [NumPartido] int NULL,
        [FechaHora] datetime2 NULL,
        [Pista] nvarchar(max) NULL,
        [Label] nvarchar(max) NULL,
        [CreatedDate] datetime NOT NULL,
        [UpdatedDate] datetime NOT NULL,
        [CreatedBy] nvarchar(256) NULL,
        [UpdatedBy] nvarchar(256) NULL,
        [Nombre] nvarchar(450) NULL,
        CONSTRAINT [PK_Partidos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_dbo.PartidoEdicion_Id] FOREIGN KEY ([GrupoId]) REFERENCES [EdicionGrupos] ([Id]),
        CONSTRAINT [FK_dbo.PartidoLocal_Id] FOREIGN KEY ([EquipoLocalId]) REFERENCES [Equipos] ([Id]),
        CONSTRAINT [FK_dbo.PartidoVisitante_Id] FOREIGN KEY ([EquipoVisitanteId]) REFERENCES [Equipos] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE TABLE [Parciales] (
        [Id] int NOT NULL IDENTITY,
        [PartidoId] int NOT NULL,
        [ResultadoLocal] int NULL,
        [ResultadoVisitante] int NULL,
        [CreatedDate] datetime NOT NULL,
        [UpdatedDate] datetime NOT NULL,
        [CreatedBy] nvarchar(256) NULL,
        [UpdatedBy] nvarchar(256) NULL,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Parciales] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_dbo.ParcialPartido_Id] FOREIGN KEY ([PartidoId]) REFERENCES [Partidos] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Categoria] ON [Categorias] ([Nombre]) WHERE [Nombre] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Competicion] ON [Competiciones] ([Nombre]) WHERE [Nombre] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Edicion] ON [Ediciones] ([Nombre]) WHERE [Nombre] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Ediciones_CategoriaId] ON [Ediciones] ([CategoriaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Ediciones_CompeticionId] ON [Ediciones] ([CompeticionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Ediciones_TemporadaId] ON [Ediciones] ([TemporadaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_EdicionGrupo] ON [EdicionGrupos] ([EdicionId], [Nombre]) WHERE [Nombre] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Equipo] ON [Equipos] ([Nombre]) WHERE [Nombre] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Equipos_EdicionGrupoId] ON [Equipos] ([EdicionGrupoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Equipos_EdicionId] ON [Equipos] ([EdicionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Jornada] ON [Jornada] ([EdicionId], [Numero]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Parciales_PartidoId] ON [Parciales] ([PartidoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Partido] ON [Partidos] ([Nombre]) WHERE [Nombre] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Partidos_EquipoLocalId] ON [Partidos] ([EquipoLocalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Partidos_EquipoVisitanteId] ON [Partidos] ([EquipoVisitanteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    CREATE INDEX [IX_Partidos_GrupoId] ON [Partidos] ([GrupoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Temporada] ON [Temporadas] ([Nombre]) WHERE [Nombre] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230410214625_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230410214625_InitialCreate', N'7.0.4');
END;
GO

COMMIT;
GO

