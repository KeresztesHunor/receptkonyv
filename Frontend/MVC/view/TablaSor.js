export default class TablaSor
{
    #receptId;
    #receptNev;
    #kategoriaId;
    #kategoriaNev;
    #kepEleresiUt;
    #leiras;

    constructor(szuloElem, adatok)
    {
        this.#receptId = adatok.id;
        this.#receptNev = adatok.nev;
        this.#kategoriaId = adatok.kategoria.id;
        this.#kategoriaNev = adatok.kategoria.nev;
        this.#kepEleresiUt = adatok.kepEleresiUt;
        this.#leiras = adatok.leiras;
        szuloElem.append(`
            <tr>
                <td>${this.#receptNev}</td>
                <td>${this.#kategoriaNev}</td>
            </tr>
        `);
        const kattintasEvent = new CustomEvent("tablaSorraKattintottEvent", { detail: this });
        szuloElem.children("tr:last-child").on("click", () => {
            window.dispatchEvent(kattintasEvent);
        });
    }
}