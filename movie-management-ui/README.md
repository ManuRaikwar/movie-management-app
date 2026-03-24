# Movie App UI (Angular)

## Overview

This is a frontend application built using Angular to interact with the Movie API.
It allows users to view, search, add, update, and delete movies with a clean UI.


## Tech Stack

* Angular (v21, Standalone Components)
* TypeScript
* RxJS
* Bootstrap / Custom CSS

## Setup Instructions

### 1. Install dependencies

```bash
npm install
```

### 2. Run the application

```bash
ng serve
```

App will be available at:

```
http://localhost:4200
```

## API Configuration

Update `movie.service.ts`:

```ts
private baseUrl = 'https://localhost:xxxx/api/movie';
```

## Features

* View latest movies
* Movie details page
* Add new movie
* Update existing movie
* Delete movie
* Search movies (single criteria)


## UI Features

* Responsive design
* Bottom-right toast notifications
* Form validation

## Toast Notifications

* Success messages (Add / Update / Delete)
* Error handling messages
* Auto-dismiss after 3 seconds

## Testing

Run tests using:

```bash
ng test
```

Includes:

* MovieService tests (API calls)
* Basic component tests

## Project Structure

```
src/app/
 ├── pages/
 ├── services/
 ├── models/
 ├── shared/
```

## Key Concepts Used

* Standalone components
* Async pipe for change detection
* Reactive service patterns using RxJS
* Routing and navigation

## Notes

* Uses async pipe to handle observable data
* Avoids manual subscriptions where possible
* Clean separation of components and services

