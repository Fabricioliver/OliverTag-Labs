# OliverTag Labs — Starter

**Missão**: repositório de lastro diário. Pequenos commits, todos os dias.

## Estrutura
```
.
├─ labs/            # experimentos rápidos
├─ kits/            # pacotes reutilizáveis
├─ projects/        # seus projetos básicos
├─ notes/           # anotações em Markdown
├─ tools/scripts/   # utilitários
└─ .github/workflows/ci.yml  # CI simples
```

## Cadência diária
- Faça 1 micro-avanço (script, doc, fix, ideia).
- `git add -A && git commit -m "chore: daily log — <resumo>" && git push`

## Como usar com seus projetos
1. Mova os 3 projetos básicos para `projects/`.
2. Se algum for boilerplate → `kits/`.
3. Se for teste rápido → `labs/`.
4. Adicione README mínimo em cada pasta.
