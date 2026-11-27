const formulario = document.getElementById('formulario');
const mensaje = document.getElementById('mensaje');
const campo = (id) => document.getElementById(id);

formulario.addEventListener('submit', async (evento) => {
  evento.preventDefault();
  const id = Number(campo('id').value) || 0;
  const producto = {
    id,
    nombre: campo('nombre').value,
    precio: Number(campo('precio').value),
    cantidad: Number(campo('cantidad').value)
  };
  const respuesta = await fetch(id ? `/api/productos/${id}` : '/api/productos', {
    method: id ? 'PUT' : 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(producto)
  });
  if (!respuesta.ok) {
    const error = await respuesta.json().catch(() => ({}));
    mensaje.textContent = error.mensaje ?? 'No se pudo guardar.';
    return;
  }
  formulario.reset();
  mensaje.textContent = 'Producto guardado.';
  await cargarProductos();
});

// reset no limpia los campos ocultos
formulario.addEventListener('reset', () => { campo('id').value = ''; mensaje.textContent = ''; });
