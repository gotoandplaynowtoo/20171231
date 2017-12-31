"use strict";

/**
 * Singleton Pattern
 *
 * @since v0.1
 */

let instance = null;

class Singleton {
    constructor() {
        if (!instance) {
            instance = this;
        }

        // just to test whether we have singleton or not
        this.time = new Date();

        return instance;
    }

    /**
     * [testFunction just a test function]
     * @return {void}
     */
    testFunction() {
        console.log('testFunction');
    }

    /**
     * [anotherTestFunction just a test function]
     * @return {void}
     */
    anotherTestFunction() {
        console.log('anotherTestFunction');
    }
}

module.exports = Singleton;
