import TablaSor from "./TablaSor.js";

export default class Tabla
{
    constructor(szuloElem, sorAdatok)
    {
        szuloElem.html(`
            <table>
                <thead>
                    <tr>
                        <th>Név</th>
                        <th>Kategória</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        `);
        const tablaBody = szuloElem.children("table").children("tbody");
        sorAdatok.forEach(sorAdat => {
            new TablaSor(tablaBody, sorAdat);
        });
    }
}