"use strict";

class ArrayHelper {

    static createEmptyArray(size, initValue) {

        var arr = [];

        for(var i = 0; i < size; i++) {
            arr.push(initValue);
        }//End of for loop

        return arr;

    }//End of createEmptyArray

}//End of ArrayHelper class
