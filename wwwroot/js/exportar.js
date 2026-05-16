window.imprimirPagina = function () {
    window.print();
};

window.descargarArchivo = function (nombre, contenido) {
    const blob = new Blob([contenido], { type: "text/csv;charset=utf-8;" });
    const link = document.createElement("a");
    link.href = URL.createObjectURL(blob);
    link.download = nombre;
    link.click();
};