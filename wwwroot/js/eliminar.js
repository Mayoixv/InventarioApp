acciones.push((p) => {
  const boton = document.createElement('button');
  boton.textContent = 'Eliminar';
  boton.addEventListener('click', async () => {
    if (!confirm(`¿Eliminar "${p.nombre}"?`)) return;
    const respuesta = await fetch(`/api/productos/${p.id}`, { method: 'DELETE' });
    if (!respuesta.ok) return alert('No se pudo eliminar.');
    await cargarProductos();
  });
  return boton;
});
