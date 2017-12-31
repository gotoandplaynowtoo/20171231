"use strict";

/**
 * Module Pattern
 *
 * @since v0.1
 */

const data = new WeakMap();

class AbstractData {
    constructor() {
        data.set(this, ['data 01', 'data 02', 'data 03']);
    }

    /**
     * [getData will get private data from WeakMap]
     * @return {void}
     */
    getData() {
        return data.get(this);
    }

    /**
     * [addData adding data to a private data WeakMap]
     * @param {String} value [will accept string for now]
     */
    addData(value) {
        if (typeof value !== 'string') {
            return;
        }

        data.get(this).push(value);
    }
}

// export our 'Class'
// which will become importable module.
module.exports = AbstractData;
