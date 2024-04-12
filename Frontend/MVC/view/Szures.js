export default class Szures
{
    constructor(szuloElem, kategoriak)
    {
        szuloElem.html(`
            <select>${(() => {
                let txt = "";
                kategoriak.forEach(kategoria => {
                    txt += `<option value="${kategoria.id}">${kategoria.nev}</option>`;
                });
                return txt;
            })()}</select>
        `);
        const select = szuloElem.children("select")
        select.on("change", event => {
            window.dispatchEvent(new CustomEvent("szures", {
                detail: {
                    kategoriaId: select.val()
                }
            }));
        });
    }
}