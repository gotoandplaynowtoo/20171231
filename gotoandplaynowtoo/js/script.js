
;(function() {

	'use strict';

	var banner = document.getElementById('banner');
	var ctx = banner.getContext('2d');
	var YEAR = '2017';

	var pageList = $.getJSON('timeline/' + YEAR + '/pages.json', function(data) {
		$.get('tpl/tpl-list.html', function(tpl) {

			data.reverse();
			
			var output = Mustache.render(tpl, {
				path: 'timeline/' + YEAR,
				list: data
			});

			$('#main').html(output);

		});
	});

	var WIDTH = banner.width = banner.parentElement.clientWidth;
	var HEIGHT =banner.height = banner.parentElement.clientHeight;	

	function Particle(x, y, size) {
		this.x = x;
		this.y = y;
		this.angle = Math.random() * Math.PI * 2;
 		this.vx = 0;
		this.vy = 0;
		this.rotation = Math.random() * Math.PI * 2;
		this.rotationSpeed = Math.random() * 0.4 - 0.2;
		this.size = size;
	}

	Particle.prototype = {
		constructor: Particle,
		reset: function() {
			this.vx = 0;
			this.vy = 0;
			this.rotationSpeed = Math.random() * 0.4 - 0.2;
		},
		update: function() {

			this.angle += Math.random() * 0.4 - 0.2;
			this.rotation += this.rotationSpeed;

			var ax = Math.cos(this.angle) * (Math.random() * 0.8 - 0.4);
			var ay =  Math.sin(this.angle) * (Math.random() * 0.8 - 0.4);

			this.vx += ax;
			this.vy += ay;

			this.x += this.vx;
			this.y += this.vy;

			if(this.x > WIDTH) {
				this.x = 0;
				this.reset();
			} 

			if(this.x < 0) {
				this.x = WIDTH;
				this.reset();
			}

			if(this.y > HEIGHT) {
				this.y = 0;
				this.reset();
			}

			if(this.y < 0) {
				this.y = HEIGHT;
				this.reset();
			}

		},
		render: function(ctx) {
			ctx.save();
			ctx.fillStyle = 'white';
			ctx.translate(this.x, this.y);
			ctx.rotate(this.rotation);
			ctx.fillRect(-this.size / 2, -this.size / 2, this.size, this.size);
			ctx.restore();

			ctx.save();
			ctx.fillStyle = 'black';
			ctx.translate(this.x, this.y);
			ctx.rotate(this.rotation);
			ctx.scale(0.98, 0.98);
			ctx.fillRect(-this.size / 2, -this.size / 2, this.size, this.size);
			ctx.restore();			
		}
	};

	var particles = [];
	var particle = null;
	var MAX_PARTICLE = 50;

	for(var i = 0; i < MAX_PARTICLE; i++) {
		particle = new Particle(WIDTH / 2, HEIGHT / 2, Math.random() * 32);
		particles.push(particle);
	}


	ctx.fillStyle = 'black';
	ctx.fillRect(0, 0, WIDTH, HEIGHT);

	requestAnimationFrame(function loop() {
		requestAnimationFrame(loop);

		for(var i = 0; i < MAX_PARTICLE; i++) {

			particle = particles[i];

			particle.update();
			particle.render(ctx);
		}

	});
	
})();