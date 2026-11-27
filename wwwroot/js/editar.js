acciones.push((p) => {
  const boton = document.createElement('button');
  boton.textContent = 'Editar';
  boton.addEventListener('click', () => {
    for (const nombre of ['id', 'nombre', 'precio', 'cantidad'])
      document.getElementById(nombre).value = p[nombre];
  });
  return boton;
});
