// Cada operacion posterior agrega aqui sus botones por fila.
const acciones = [];
const tabla = document.getElementById('productos');

async function cargarProductos() {
  const respuesta = await fetch('/api/productos');
  if (!respuesta.ok) return alert('No se pudo cargar la lista. Revisa la base de datos.');
  const productos = await respuesta.json();
  tabla.replaceChildren();
  for (const p of productos) {
    const fila = tabla.insertRow();
    for (const valor of [p.id, p.nombre, p.precio.toFixed(2), p.cantidad])
      fila.insertCell().textContent = valor;
    const celda = fila.insertCell();
    for (const crearBoton of acciones) celda.append(crearBoton(p));
  }
}

// Espera a que carguen los demas scripts antes de pintar la tabla.
document.addEventListener('DOMContentLoaded', cargarProductos);
