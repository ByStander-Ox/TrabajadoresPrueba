USE TrabajadoresPrueba;
GO

INSERT INTO Trabajadores (Nombres, Apellidos, TipoDocumento, NumeroDocumento, Sexo, FechaNacimiento, Foto, Direccion)
VALUES
('Juan Carlos', 'Ramírez Soto', 'DNI', '45872145', 'Masculino', '1990-03-15',
 'https://randomuser.me/api/portraits/men/32.jpg', 'Av. Los Pinos 123 - Lima'),

('María Fernanda', 'Pérez Gómez', 'DNI', '73214568', 'Femenino', '1992-11-22',
 'https://randomuser.me/api/portraits/women/44.jpg', 'Jr. Las Orquídeas 450 - Arequipa'),

('Carlos Eduardo', 'Mendoza Quiroz', 'CE', 'CE984512', 'Masculino', '1987-06-08',
 'https://randomuser.me/api/portraits/men/27.jpg', 'Urb. Primavera 120 - Trujillo'),

('Lucía Andrea', 'Salazar Ruiz', 'Pasaporte', 'P1234567', 'Femenino', '1995-02-10',
 'https://randomuser.me/api/portraits/women/55.jpg', 'Calle Los Álamos 99 - Cusco'),

('Ricardo Javier', 'Torres Valdez', 'DNI', '48795123', 'Masculino', '1985-08-01',
 'https://randomuser.me/api/portraits/men/41.jpg', 'Mz B Lt 15 Urb. San Pedro - Piura');
GO
