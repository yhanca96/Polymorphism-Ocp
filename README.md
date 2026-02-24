# 🛒 Motor de Cálculos: OCP & Polimorfismo (Pricing Engine)

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-Testing-success?style=for-the-badge)

Este repositorio contiene la demostración arquitectónica de un **Motor de Cálculo de Descuentos** para un E-commerce. El objetivo principal es evidenciar la refactorización de un sistema monolítico y altamente acoplado (*Legacy*) hacia una arquitectura limpia y escalable utilizando el **Principio Abierto/Cerrado (OCP)** y **Polimorfismo**.

---

## 📖 Descripción del Proyecto

En el desarrollo de software para comercio electrónico, las reglas de negocio (promociones, cupones, fidelización) cambian constantemente. 

Este proyecto ilustra dos enfoques para resolver el cálculo de un carrito de compras:
1. **El Enfoque Legacy (El Problema):** Un motor procedimental basado en múltiples condicionales anidados (`if/else` y `switch`). Modificar o agregar un nuevo descuento obliga a alterar el código de producción central, violando el principio OCP y generando pruebas unitarias frágiles.
2. **El Enfoque Refactorizado (La Solución):** Una arquitectura basada en el patrón de diseño **Strategy**. Utilizando la Inversión de Dependencias y el Despacho Polimórfico, el motor central es capaz de calcular el mejor descuento posible sin conocer las reglas matemáticas subyacentes. 

> **Resultado:** El nuevo motor de cálculo está *Abierto a la extensión* (podemos agregar infinitas promociones nuevas) pero *Cerrado a la modificación* (el núcleo del motor jamás se vuelve a tocar).

---

## 🏗️ Estructura de la Solución

La solución está dividida estratégicamente en 4 capas para garantizar la Separación de Responsabilidades (Separation of Concerns):

* **`1. Domain`**: Contiene el núcleo del negocio (`Order`, `User`, `UserType`). Entidades puras, altamente cohesivas y 100% agnósticas a las lógicas de campañas de marketing.
* **`2. LegacyCode`**: Contiene la clase `DiscountCalculator`. Es el anti-patrón que demuestra la complejidad ciclomática y el acoplamiento rígido.
* **`3. RefactorCode`**: Contiene la solución limpia. Interfaces (`IDiscountStrategy`), implementaciones concretas de reglas de negocio y el orquestador polimórfico (`OcpDiscountCalculator`).
* **`4. Tests`**: Conjunto de pruebas unitarias (xUnit) que contrastan la fragilidad del código Legacy (crecimiento combinatorio) frente a la robustez y testeabilidad del código refactorizado (crecimiento lineal con Mocks).

---

## 🗺️ Documentación Visual

### Diagrama de Clases (UML)
El siguiente diagrama ilustra cómo el patrón Strategy desacopla las reglas de negocio del cálculo central. El orquestador (`OcpDiscountCalculator`) solo depende de la abstracción (`IDiscountStrategy`), permitiendo inyectar dependencias en tiempo de ejecución.

> *Nota: Asegúrate de subir el archivo de imagen al repositorio para que se visualice correctamente.*
![UML Diagram](./UML%20Class%20Diagram_%20Discount%20System%20Strategy%20Pattern.png)

### Arquitectura C4 (Contexto y Contenedores)
El diseño del sistema permite que el equipo de Marketing genere nuevas reglas de negocio de forma aislada sin afectar el flujo de compra del Cliente final. 
*Puedes revisar el modelo interactivo descargando el archivo `C4Arquitectura.html` incluido en este repositorio.*

---

## ⚙️ Conceptos Clave Aplicados

* **Open/Closed Principle (OCP):** Las entidades de software (clases, módulos, funciones) deben estar abiertas para su extensión, pero cerradas para su modificación.
* **Polimorfismo:** Capacidad de una interfaz para representar múltiples implementaciones subyacentes.
* **Inyección de Dependencias (DI):** Inversión de control aplicada en el constructor del motor de cálculo para recibir sus dependencias (`IEnumerable<IDiscountStrategy>`) desde el exterior.
* **Programación Defensiva y LINQ:** Manejo de colisiones de negocio mediante evaluación dinámica de colecciones.

### 📚 Recursos Adicionales
Para una lectura más profunda sobre los fundamentos teóricos aplicados en este proyecto, consulta nuestra documentación externa:
🔗 **[Conceptos de OCP y Polimorfismo](https://teo-o.github.io/OCP/concepto-ocp-polimorfismo.html)**

---
*Desarrollado para la demostración de Principios de Diseño de Software y Clean Architecture.*
