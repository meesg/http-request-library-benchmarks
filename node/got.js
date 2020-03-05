const got = require('got');
const config = require('./config')

const url = config.url;

function singleRequest(url) {
	return new Promise(function(resolve, reject) {       
		(async () => {
			try {
				let start = Date.now();
				const response = await got(url);
				let end = Date.now();

				resolve(end - start);
			} catch (error) {
				reject(error.response.body);
			}
		})();
	});
}

function synchAverage(n) {
	let total = 0;
	const promises = [];

	for (let i = 0; i < n; i++) {
		promises.push(singleRequest(url));
	}

	Promise.all(promises).then(function(values) {
		let total = 0;
		for (let i = 0; i < n; i++) {
			total += values[i];
		}

		let average = total / n;
		console.log(`Average response time over ${n} synchronous request: ${average}`);
	});
}

async function asynchAverage(n) {
	let total = 0;
	const promises = [];

	for (let i = 0; i < n; i++) {
		await singleRequest(url).then(function(time) {
			total += time;
		});
	}

	let average = total / n;
	console.log(`Average response time over ${n} asynchronous request: ${average}`);
}

async function main() {
	synchAverage(1);
	await asynchAverage(1);
	timeout(5000);

	synchAverage(10);
	await asynchAverage(10);
	timeout(5000);

	synchAverage(100);
	await asynchAverage(100);
} 

function timeout(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

main();
