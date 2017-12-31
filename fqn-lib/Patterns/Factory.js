"use strict";

class Factory {

    constructor() {
        this.factories = {};
    }

    /**
     * Used for adding new factory.
     * @param {String} factoryName    name of the factory.
     * @param {function} createFunction factory create function.
     */
    add(factoryName, createFunction) {
        this.factories[factoryName] = createFunction;
    }

    /**
     * Used for removing a factory.
     * @param  {String} factoryName name of the factory to remove.
     * @return {Void}             no return.
     */
    remove(factoryName) {
        if(this.factories[factoryName]) {
            delete this.factories[factoryName];
        }
    }

    /**
     * Used to execute create function of a factory.
     * @param  {String} factoryName factory name to create.
     * @return {Void}             no return.
     */
    create(factoryName) {
        return this.factories[factoryName]();
    }

}
