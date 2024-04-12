export default class DataService
{
    #urlBase;

    constructor(urlBase)
    {
        this.#urlBase = urlBase;
    }

    get(path, callback)
    {
        axios
            .get(this.#urlBase + "/" + path)
            .then(callback)
            .catch(console.error)
        ;
    }

    post(path, object, callback)
    {
        axios
            .post(this.#urlBase + "/" + path, object)
            .then(callback)
            .catch(console.error)
        ;
    }

    delete(path, callback)
    {
        axios
            .delete(this.#urlBase + "/" + path)
            .then(callback)
            .catch(console.error)
        ;
    }
}