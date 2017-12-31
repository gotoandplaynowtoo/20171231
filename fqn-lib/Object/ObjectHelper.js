"use strict";

/**
* ObjectHelper v0.1
*/
class ObjectHelper {

    /**
     * Used for merging objects.
     * @param  {Object} obj1 target object where we merge.
     * @param  {Object} obj2 object to merge to the target.
     * @return {Void}      no return.
     */
    static merge(obj1, obj2) {

        var merged = ObjectHelper.cloneProps(obj1);

        Object.keys(obj2).forEach(key => {
            if(obj2.hasOwnProperty(key)) {
                merged[key] = obj2[key];
            }
        });

        return merged;

    }

    /**
    * Used for cloning object literal.
    * @param  {Object} obj Object literal to clone.
    * @return {Object}     Object Literal copy.
    */
    static cloneProps() {

        var copied = {};
        var obj = null;
        var args = Array.prototype.slice.call(arguments);

        for(var i = 0, len = args.length; i < len; i++) {

            obj = args[i];

            if(!(obj instanceof Object)) continue;

            Object.keys(obj).forEach(key => {
                if(obj.hasOwnProperty(key)) {
                    copied[key] = obj[key];
                }
            });

        }//End of for loop

        return copied;
    } //End of clone method

}//End of class ObjectHelper

module.exports = ObjectHelper;
