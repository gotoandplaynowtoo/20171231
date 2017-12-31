"use strict";

const Observer = require('./Observer.js');

/**
 * Mediator Pattern
 *
 * @since v0.1
 */

class Mediator extends Observer {
    constructor() {
        super();
    }

    /**
     * [attach will attach events and object from observer]
     * @param  {Object} obj [copy of observer object]
     * @return {void}
     */
    attach(obj) {
        if (typeof obj !== 'object') {
            return;
        }

        obj.listeners = {};
        obj.on = this.on;
        obj.emit = this.emit;
    }
}

module.exports = Mediator;
