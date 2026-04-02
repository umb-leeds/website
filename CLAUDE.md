# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Umbraco Leeds community meetup website (umbleeds.org.uk). This is a static site hosted on Vercel — no build step, no framework, no bundler.

## Architecture

- **`public/`** — All site content. Vercel serves this directory as the web root.
  - Static HTML pages (`index.html`, `about/index.html`, `code-of-conduct/index.html`, `gallery/index.html`)
  - Single shared stylesheet (`styles.css`) using CSS custom properties for brand tokens
  - SVG logos and event photography in `images/`
- **`vercel.json`** — Vercel config with security headers (X-Content-Type-Options, X-Frame-Options)
- **`deploy.cmd`** / **`.deployment`** — Legacy Azure/Kudu deployment scripts (no longer active)

## Development

No build, install, or test commands. Edit the HTML/CSS directly. To preview locally, serve the `public/` directory with any static server:

```
npx serve public
```

## Deployment

Pushes to `main` trigger Vercel deployment automatically. The site is served from the `public/` directory.

## Brand Tokens

Defined as CSS custom properties in `styles.css`:
- `--blue: #1F4774` (primary), `--yellow: #F5D354` (accent)
- `--max-w: 1100px` (content max-width)
