USE [ProyectoSocioeconomicoDB]
GO

-- 1. ROLES (primero, porque Usuarios lo necesita)
INSERT INTO [dbo].[Roles] (Nombre, Descripcion, Estado)
VALUES 
('Admin', 'Administrador del sistema con acceso total', 'Activo'),
('Donador', 'Usuario que realiza donaciones a los casos', 'Activo'),
('Beneficiado', 'Usuario que crea casos y recibe ayuda', 'Activo'),
('Analista', 'Usuario que analiza datos y reportes del sistema', 'Activo');
GO

-- 2. USUARIOS (segundo, es la tabla más referenciada)
INSERT INTO [dbo].[Usuarios] 
(Nombre, Apellido, Email, PasswordHash, FechaNacimiento, DUI, Telefono, Direccion, 
 ImagenPerfil, FrontDUI, ReverseDUI, IdRol, Estado, FechaRegistro)
VALUES
('Carlos', 'Mendoza', 'carlos.admin@proyecto.com', 'AQAAAAIAAYagAAAAE...', '1985-03-15', '01234567-8', '7012-3456', 'San Salvador', NULL, 'front1.jpg', 'reverse1.jpg', 1, 'Activo', GETDATE()),
('Ana', 'López', 'ana.lopez@gmail.com', 'AQAAAAIAAYagAAAAE...', '1992-07-22', '03456789-0', '7890-1234', 'Santa Tecla', NULL, 'front2.jpg', 'reverse2.jpg', 2, 'Activo', GETDATE()),
('Roberto', 'García', 'roberto.donador@hotmail.com', 'AQAAAAIAAYagAAAAE...', '1988-11-10', '04567890-1', '6123-4567', 'San Salvador', NULL, 'front3.jpg', 'reverse3.jpg', 2, 'Activo', GETDATE()),
('María', 'Hernández', 'maria.dona@gmail.com', 'AQAAAAIAAYagAAAAE...', '1995-04-05', '05678901-2', '7234-5678', 'Antiguo Cuscatlán', NULL, 'front4.jpg', 'reverse4.jpg', 2, 'Activo', GETDATE()),
('José', 'Ramírez', 'jose.ramirez@yahoo.com', 'AQAAAAIAAYagAAAAE...', '1980-09-30', '06789012-3', '6345-6789', 'Soyapango', NULL, 'front5.jpg', 'reverse5.jpg', 2, 'Activo', GETDATE()),
('Elena', 'Morales', 'elena.beneficiada@gmail.com', 'AQAAAAIAAYagAAAAE...', '1998-01-12', '07890123-4', '7456-7890', 'San Salvador', NULL, 'front6.jpg', 'reverse6.jpg', 3, 'Activo', GETDATE()),
('Luis', 'Pérez', 'luis.beneficiado@outlook.com', 'AQAAAAIAAYagAAAAE...', '1975-06-25', '08901234-5', '8567-8901', 'Apopa', NULL, 'front7.jpg', 'reverse7.jpg', 3, 'Activo', GETDATE()),
('Carmen', 'Díaz', 'carmen.necesitada@gmail.com', 'AQAAAAIAAYagAAAAE...', '2000-03-18', '09012345-6', '9678-9012', 'Mejicanos', NULL, 'front8.jpg', 'reverse8.jpg', 3, 'Activo', GETDATE()),
('Laura', 'Vásquez', 'laura.analista@proyecto.com', 'AQAAAAIAAYagAAAAE...', '1990-08-14', '11234567-8', '7890-1234', 'San Salvador', NULL, 'front10.jpg', 'reverse10.jpg', 4, 'Activo', GETDATE());
GO

-- 3. CATEGORÍAS
INSERT INTO [dbo].[Categorias] (Nombre, Descripcion, Estado)
VALUES
('Salud', 'Tratamientos médicos, operaciones y medicinas', 'Activo'),
('Educación', 'Apoyo para estudios y materiales escolares', 'Activo'),
('Vivienda', 'Construcción y reparación de vivienda', 'Activo'),
('Alimentación', 'Despensas y apoyo nutricional', 'Activo'),
('Emprendimiento', 'Apoyo para pequeños negocios', 'Activo');
GO

-- 4. PROGRAMAS (ahora sí puede referenciar usuarios)
INSERT INTO [dbo].[Programas] (Nombre, Descripcion, ImagenUrl, Estado, FechaCreacion, CreadoPor)
VALUES
('Programa de Salud Infantil', 'Atención médica para niños vulnerables', 'https://ejemplo.com/img/salud.jpg', 'Activo', GETDATE(), 1),
('Becas Educativas', 'Apoyo para estudiantes de primaria y secundaria', 'https://ejemplo.com/img/educacion.jpg', 'Activo', GETDATE(), 1),
('Reconstrucción de Hogares', 'Ayuda tras desastres naturales', 'https://ejemplo.com/img/vivienda.jpg', 'Activo', GETDATE(), 1),
('Despensas Solidarias', 'Entrega de alimentos a familias', 'https://ejemplo.com/img/alimentos.jpg', 'Activo', GETDATE(), 1);
GO

-- 5. CASOS
INSERT INTO [dbo].[Casos] 
(IdBeneficiado, Titulo, Descripcion, ImagenUrl, Meta, FechaLimite, IdCategoria, Estado, FechaCreacion)
VALUES
(6, 'Operación de corazón para mi hijo', 'Necesito ayuda para la cirugía cardiovascular de mi hijo de 8 años.', 'https://ejemplo.com/casos/operacion.jpg', 4500.00, '2026-06-30', 1, 'Activo', GETDATE()),
(7, 'Uniformes y útiles escolares', 'Apoyo para 3 hijos en la escuela.', 'https://ejemplo.com/casos/educacion.jpg', 850.00, '2026-05-15', 2, 'Activo', GETDATE()),
(8, 'Reparación de casa tras inundación', 'Mi casa sufrió daños por la tormenta.', 'https://ejemplo.com/casos/inundacion.jpg', 3200.00, '2026-07-10', 3, 'Activo', GETDATE()),
(6, 'Tratamiento de cáncer', 'Medicamentos y quimioterapia.', 'https://ejemplo.com/casos/cancer.jpg', 5800.00, '2026-08-20', 1, 'Activo', GETDATE());
GO

-- 6. CASOSPROGRAMAS
INSERT INTO [dbo].[CasosProgramas] (IdCaso, IdPrograma)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 1);
GO

-- 7. DONACIONES (después de Casos y Usuarios)
INSERT INTO [dbo].[Donaciones] 
(IdCaso, IdDonador, Monto, Anonimo, FechaDonacion, Estado, MetodoPago)
VALUES
(1, 2, 500.00, 0, GETDATE(), 'Completada', 'Tarjeta'),
(1, 3, 250.00, 1, GETDATE(), 'Completada', 'Transferencia'),
(2, 4, 100.00, 0, GETDATE(), 'Completada', 'Tarjeta'),
(3, 2, 300.00, 0, GETDATE(), 'Completada', 'Transferencia');
GO

-- 8. COMPROBANTES (después de Donaciones)
INSERT INTO [dbo].[Comprobantes] 
(IdDonacion, UrlArchivo, FechaSubida, CodigoComprobante, DonacionId)
VALUES
(1, 'https://ejemplo.com/comp1.pdf', GETDATE(), 'COMP-001', 1),
(2, 'https://ejemplo.com/comp2.pdf', GETDATE(), 'COMP-002', 2);
GO

-- 9. INSCRIPCIONES VOLUNTARIOS
INSERT INTO [dbo].[InscripcionesVoluntarios] 
(IdPrograma, IdUsuario, FechaInscripcion, Estado)
VALUES
(1, 2, GETDATE(), 'Aprobada'),
(2, 3, GETDATE(), 'Pendiente');
GO

-- 10. NOTIFICACIONES (al final)
INSERT INTO [dbo].[Notificaciones] 
(IdUsuario, Mensaje, Leida, FechaEnvio, Tipo, Titulo, UsuarioId)
VALUES
(6, '¡Tu caso recibió una nueva donación!', 0, GETDATE(), 'Donacion', 'Nueva Donación', 6),
(2, 'Gracias por tu donación al caso de operación.', 1, GETDATE(), 'Agradecimiento', 'Donación Exitosa', 2);
GO