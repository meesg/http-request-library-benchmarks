# http-request-library-benchmarks
  
  
## Notes

In the node code, the synchronous functions should also be await-ed to make it a little bit more fair.
 
## results

### node

#### got

website: https://httpbin.org/get  
location: university library  
time: 2020-03-05T11:28:00+01:00  
	Average response time over 1 synchronous request: 427  
	Average response time over 1 asynchronous request: 429  
	Average response time over 10 synchronous request: 444.6  
	Average response time over 10 asynchronous request: 424.8  
	Average response time over 100 synchronous request: 442.36  
	Average response time over 100 asynchronous request: 309.94  
  
website: https://httpbin.org/get  
location: university library  
time: 2020-03-05T11:39:00+01:00  
	Average response time over 1 synchronous request: 426  
	Average response time over 1 asynchronous request: 710  
	Average response time over 10 synchronous request: 314.9  
	Average response time over 10 asynchronous request: 308.8  
	Average response time over 100 synchronous request: 429.18  
	Average response time over 100 asynchronous request: 329.35  
  
#### superagent
website: https://httpbin.org/get  
location: university library  
time: 2020-03-05T11:39:00+01:00  
	Average response time over 1 synchronous request: 429  
	Average response time over 1 asynchronous request: 433  
	Average response time over 10 synchronous request: 403.4  
	Average response time over 10 asynchronous request: 422.6  
	Average response time over 100 synchronous request: 678.37  
	Average response time over 100 asynchronous request: 428.31  

### C-sharp

#### HttpClient 
website: https://httpbin.org/get  
location: university library  
time: 2020-03-05T15:30:00+01:00  
	Average response time over 1 synchronous request:400  
	Average response time over 1 asynchronous request:189  
	Average response time over 10 synchronous request:182  
	Average response time over 10 asynchronous request:100  
	Average response time over 100 synchronous request:235  
	Average response time over 100 asynchronous request:119