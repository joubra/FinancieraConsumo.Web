window.imprimirPagina = function () {
    window.print();
};

window.descargarArchivo = function (nombre, contenido) {
    const blob = new Blob([contenido], { type: "text/csv;charset=utf-8;" });
    const link = document.createElement("a");
    link.href = URL.createObjectURL(blob);
    link.download = nombre;
    link.click();
    window.imprimirHtml = function (html) {
        const ventana = window.open('', '_blank');
        ventana.document.write(html);
        ventana.document.close();
        ventana.focus();

        setTimeout(() => {
            ventana.print();
        }, 500);
    };
};
window.imprimirHtml = function (html) {
    const ventana = window.open('', '_blank');

    if (!ventana) {
        alert("Permita ventanas emergentes para imprimir");
        return;
    }

    ventana.document.open();
    ventana.document.write(html);
    ventana.document.close();

    setTimeout(() => {
        ventana.focus();
        ventana.print();
    }, 500);
};