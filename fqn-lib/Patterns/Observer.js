"use strict";

/**
 * Observer pattern v0.1
 */
class Observer {

    constructor() {
        this.listeners = {};
    }//End of constructor

    /**
     * Used for emitting and event in the observer.
     * @param  {String} eventName name of the event you want to fire.
     * @param  {String} args      event object.
     * @return {Void}           no return.
     */
    emit(eventName, args) {
        if(this.listeners[eventName]) {
            this.listeners[eventName].forEach(handler => {
                handler(args);
            });
        }
    }//End of emit method

    /**
     * Used for listening an event.
     * @param  {String} eventName event name to listen.
     * @param  {Function} handler   event handler.
     * @return {Void}           no return.
     */
    on(eventName, handler) {

        this.listeners[eventName] = this.listeners[eventName] || [];
        this.listeners[eventName].push(handler);

    }//End of on method

    /**
     * Used for removing events.
     * @param  {String} eventName event name to remove
     * @param  {Function} handler   handler to remove.
     * @return {Void}           no return.
     */
    off(eventName, handler) {

        if(!this.listeners[eventName])
            return;

        var idx = -1;

        do {
            idx = this.listeners[eventName].indexOf(handler);
            this.listeners[eventName].splice(idx, 1);
        } while(idx !== -1);

        if(this.listeners[eventName].length === 0)
            delete this.listeners[eventName];

    }//End of off method

}//End of class Observer

module.exports = Observer;
