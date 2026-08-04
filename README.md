# GitSomeJava Order API

Demo repository for **Securing Your Software Supply Chain** (TechMentor
CT14). Nothing here is production software.

The interesting files are the workflows:

| File | Role |
|---|---|
| `.github/workflows/secure-release.yml` | The hardened pipeline — Demos 3, 4, 5 |
| `.github/workflows/legacy-deploy.yml` | The anti-pattern, kept for contrast. Disabled. |
| `.github/workflows/dependency-review.yml` | The gate that blocks PR #12 — Demo 1 |
