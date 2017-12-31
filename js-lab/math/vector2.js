
export class Vector2 {
    constructor(x = 0, y  = 0) {
        this.x = x;
        this.y = y;
    }
    add(v2) {
        this.x += v2.x;
        this.y += v2.y;
    }
}

