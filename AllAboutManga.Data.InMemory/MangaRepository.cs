﻿using AllAboutManga.Data.Libs;
using System;
using System.Collections.Generic;
using AllAboutManga.Data.Libs.Models;
using System.Threading.Tasks;
using System.Linq;

namespace AllAboutManga.Data.InMemory
{
    public class MangaRepository : IMangaRepository
    {
        private readonly List<Manga> _mangaDb = new List<Manga>();

        public async Task<bool> AnyAsync()
        {
            await Task.FromResult<object>(null);
            return _mangaDb.Count > 0;
        }

        public async Task CreateAsync(Manga manga)
        {
            _mangaDb.Add(manga);
            await Task.FromResult<object>(null);
        }

        public async Task CreateAsync(IEnumerable<Manga> mangas)
        {
            _mangaDb.AddRange(mangas);
            await Task.FromResult<object>(null);
        }

        public async Task ClearAsync()
        {
            _mangaDb.Clear();
            await Task.FromResult<object>(null);
        }

        public async Task DeleteAsync(string mangaId)
        {
            await Task.FromResult<object>(null);
            _mangaDb.RemoveAll(manga => manga.Id == mangaId);
        }

        public async Task<Manga> GetByIdAsync(string id)
        {
            await Task.FromResult<object>(null);
            return _mangaDb.Find(manga => manga.Id == id);
        }

        public async Task<Manga> UpdateAsync(Manga newManga)
        {
            var oldManga = _mangaDb.Find(manga => manga.Id == newManga.Id);
            if (oldManga != null)
            {
                _mangaDb.Remove(oldManga);
            }

            _mangaDb.Add(newManga);
            await Task.FromResult<object>(null);
            return newManga;
        }

        public async Task<IReadOnlyCollection<Manga>> GetAllAsync()
        {
            await Task.FromResult<object>(null);
            return _mangaDb;
        }

        public async Task<IReadOnlyCollection<Manga>> QueryAsync(Func<Manga, bool> predicate)
        {
            await Task.FromResult<object>(null);

            return _mangaDb
                .Where(predicate)
                .ToList();
        }
    }
}
