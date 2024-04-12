import DataService from "../model/DataService.js";
import Szures from "../view/Szures.js";
import Tabla from "../view/Tabla.js";

export default class TablaController
{
    #dataService;

    constructor()
    {
        this.#dataService = new DataService("http://localhost:5042");
        this.#dataService.get("kategoriak", response => {
            new Szures($("#szures"), response.data);
        });
        $(window).on("szures", event =>{
            console.log(event.detail);
        });
        this.#dataService.get("receptek", response => {
            new Tabla($("#tabla"), response.data);
        });
        $(window).on("tablaSorraKattintottEvent", event => {
            
        });
    }
}