# SimpleNoSQLGuestbook

This is intended as an example of using ASP.NET Core with Redis on containers rather than a proper guestbook. It's stripped down to a bare minimum of functions - no auth, rate limiting, etc.

## Running

Just type ```docker-compose up``` and wait for Compose to finish its magic.

Navigate to [http://localhost:8000](http://localhost:8000) to see the results.

## Q&A

### Why?

I haven't found any good examples of *simple* ASP.NET app with Redis backend running in Docker. So I've built one.

### Should I use it in production?

Probably not.