// Función para copiar texto al portapapeles y mostrar una marca de verificación
function copyText(text, button) {
    // Si el modo de mayúsculas está activado, convertir el texto a mayúsculas antes de copiar
    if (isUppercase) {
        text = text.toUpperCase();
    }
    
    navigator.clipboard.writeText(text).then(() => {
        button.innerHTML = "✓"; // Cambiar a checkmark al copiar
        setTimeout(() => {
            button.innerHTML = "Copy"; // Restaurar el botón después de 2 segundos
        }, 2000);
    });
}

// Función para cargar y renderizar traducciones desde un archivo JSON
function loadTranslations(jsonFile, tableSelector) {
    fetch(jsonFile)
        .then(response => response.json())
        .then(data => {
            const table = document.querySelector(tableSelector);
            let translationsKey = Object.keys(data)[0]; // Obtén la clave principal del JSON (e.g., "translations", "dino")
            data[translationsKey].forEach((item, index) => {
                const row = document.createElement('div');
                row.classList.add('row');
                row.innerHTML = `
                    <div class='index'>${index + 1}</div>
                    <div class="box">${item.es}</div>
                    <button class="copy-btn" onclick="copyText('${item.es}', this)">Copy</button>

                    <div class="box">${item.en}</div>
                    <button class="copy-btn" onclick="copyText('${item.en}', this)">Copy</button>
                    
                    <div class="box">${item.qu}</div>
                    <button class="copy-btn" onclick="copyText('${item.qu}', this)">Copy</button>
                `;
                table.appendChild(row);
            });
        });
}

// Cargar traducciones del archivo "translations.json" en la sección de menú
loadTranslations('translations.json', '.menu-translations');

// Cargar traducciones del archivo "di-no.json" en la sección de Di-no
loadTranslations('di-no.json', '.di-no-translations');

// Cargar traducciones del archivo "tarija.json" en la sección de Tarija
loadTranslations('tarija.json', '.tarija');

// Función para cambiar entre modo oscuro y claro
document.getElementById('theme-toggle-btn').addEventListener('click', function () {
    document.body.classList.toggle('dark-mode');
    
    // Cambia el texto del botón dependiendo del modo
    if (document.body.classList.contains('dark-mode')) {
        this.textContent = 'Modo Claro';
    } else {
        this.textContent = 'Modo Oscuro';
    }
});

// Function to toggle uppercase
const uppercaseToggle = document.getElementById('uppercase-toggle');
let isUppercase = false;

uppercaseToggle.addEventListener('click', () => {
    const textBoxes = document.querySelectorAll('.box');
    textBoxes.forEach(box => {
        if (isUppercase) {
            box.textContent = box.textContent.toLowerCase();
            box.style.textTransform = "none";
        } else {
            box.textContent = box.textContent.toUpperCase();
            box.style.textTransform = "uppercase";
        }
    });
    isUppercase = !isUppercase;
});