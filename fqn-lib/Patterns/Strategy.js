"use strict";
/**
 * Strategy Pattern v0.1
 */
class Strategy {

    constructor() {
        this.strategy = {};
    }

    /**
     * Used for adding new strategy.
     * @param {String} strategyName  name of the strategy.
     * @param {Function} strategyValue strategy function as value.
     */
    add(strategyName, strategyValue) {
        this.strategy[strategyName] = strategyValue;
    }

    /**
     * Used for removing strategy.
     * @param  {String} strategyName the name of the strategy.
     * @return {Void}              no return.
     */
    remove(strategyName) {
        if(this.strategy[strategyName]) {
            delete this.strategy[strategyName];
        }
    }

    /**
     * Used for running a strategy value.
     * @param  {String} strategyName strategy name to run.
     * @param  {Mix} args         Strategy arguments.
     * @return {Mix}              Strategy returned value.
     */
    run(strategyName, args) {
        return this.strategy[strategyName] && this.strategy[strategyName](args);
    }

}
